using MauiDnd.Models;
using MauiDnd.Views;
using MauiDnd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiDnd
{
    public class DndClient
    {
        private readonly HttpClient httpClient;
        public int UserId { get;private set; }
        private static DndClient Instance;
        private const string BaseUrl = "https://8xf3d6m4-7048.use.devtunnels.ms";

        #region ENDPOINTS
        private readonly string GET_ALL_CHARACTERS_ENDPOINT = "/api/Characters";
        private readonly string GET_CHARACTER_ENDPOINT = "/api/Characters/";
        private readonly string GET_CHARACTER_OF_USER_ENDPOINT = "/api/Characters/user/";
        private readonly string POST_RANDOM_CHARACTER = "/api/Characters/RandomCharacter/user/";
        private readonly string DELETE_CHARACTER = "/api/Characters/";
        private readonly string PUT_CHARACTER = "/api/Characters/";
        private readonly string GET_CLASSES = "/api/Class/";
        private readonly string GET_CLASS_BY_NAME = "/api/Class/name/";
        private readonly string GET_INVENTORY = "/api/Characters/{0}/Inventory";
        private readonly string PUT_INVENTORY_BOX = "/api/InventoryBoxes/";
        private readonly string GET_GAMES = "/api/Games";
        private readonly string ADD_CHARACTER_To_GAME = "/api/Characters/joinGame/{0}/Game/{1}";
        private readonly string GET_LOCATION_OF_PLAYER = "/api/Games/GetLocation/{0}/Character/{1}";
        private readonly string POST_LOCATION_OF_PLAYER = "/api/Games/{0}/Character/{1}/SetLocation/{2}/{3}";
        private readonly string GET_DICE_10 = "/api/utils/dice10";
        private readonly string FIGHT = "/api/Games/{0}/Character/{1}/fight/{2}?hp={3}";
        private readonly string GET_SPAWN_POINT = "/api/SpawnPoints/";
        private readonly string GET_ARMOR = "/api/Armor/";
        private readonly string GET_WEAPON = "/api/Weapons/";
        private readonly string GET_HP_OF_CHARACTER = "/api/Games/GetPv/{0}/Character/{1}";
        private readonly string GET_MONSTER = "/api/Monster/";
        private readonly string POST_GAME = "/api/Games";
        private readonly string POST_CHARACTER = "/api/Characters/NewCharacter";
        private readonly string INCREMENT_LEVEL = "/api/Characters/IncrementLevel/";
        private readonly string GET_FEAT = "/api/Feats";
        private readonly string GET_SPELL = "/api/Spell";


        #endregion

        private DndClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            UserId = 1;
        }

        //singleton pour ne pas réinstancier la class
        public static DndClient Client()
        {
            if(Instance is null)
            {
                Instance = new DndClient();
            }
            return Instance;
        }

        //on devrait se login mais on a pas le temps
        public void Login(string username, string password)
        {
            UserId = 1;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            List<Character> characters = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_ALL_CHARACTERS_ENDPOINT);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                characters = JsonConvert.DeserializeObject<List<Character>>(jsonContent);
            }
            return characters;
        }
        public async Task IncrementLevel(int id)
        {
            await httpClient.PutAsync(INCREMENT_LEVEL + id, null);
        }
        public async Task PostGameAsync()
        {
            await httpClient.PostAsync(POST_GAME,null);
        }
        public async Task PostCharacterAsync(Character c)
        {
            var jsonContent = JsonConvert.SerializeObject(c);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await httpClient.PostAsync(POST_CHARACTER, stringContent);
        }
        public async Task<Monster> GetMonster(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_MONSTER + id);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Monster>(jsonContent);
            }
            return null;
        }

        public async Task<List<Monster>> GetMonsterAsync()
        {
            List<Monster> monsters = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_MONSTER);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                monsters = JsonConvert.DeserializeObject<List<Monster>>(jsonContent);
                return monsters;

            }
            return null;
        }

        public async Task<List<Weapon>> GetWeaponAsync()
        {
            List<Weapon> weapons = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_WEAPON);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                weapons = JsonConvert.DeserializeObject<List<Weapon>> (jsonContent);
                return weapons;

            }
            return null;
        }

        public async Task<List<Armor>> GetArmorAsync()
        {
            List<Armor> armor = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_ARMOR);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                armor = JsonConvert.DeserializeObject<List<Armor>>(jsonContent);
                return armor;

            }
            return null;
        }

        public async Task<int?> GetHpOfCharacterAsync(int gameId, int characterId)
        {
            HttpResponseMessage response = await httpClient.GetAsync(string.Format(GET_HP_OF_CHARACTER,gameId, characterId));

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(jsonContent);
            }
            return null;
        }

        public async Task SetLocationOfPlayerAsync(int gameId, int characterId, int x, int y)
        {
            HttpResponseMessage response = await httpClient.PostAsync(string.Format(POST_LOCATION_OF_PLAYER, gameId, characterId, x, y), null);
        }

        public async Task<List<Class>> GetClassAsync()
        {
            List<Class> classes = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_CLASSES);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                classes = JsonConvert.DeserializeObject<List<Class>>(jsonContent);
            }
            return classes;
        }

        public async Task<List<Spell>> GetSpellAsync()
        {
            List<Spell> spell = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_SPELL);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                spell = JsonConvert.DeserializeObject<List<Spell>>(jsonContent);
                return spell;

            }
            return null;
        }
        public async Task<List<Feat>> GetFeatAsync()
        {
            List<Feat> feats = null;

            HttpResponseMessage response = await httpClient.GetAsync(GET_FEAT);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                feats = JsonConvert.DeserializeObject<List<Feat>>(jsonContent);
                return feats;

            }
            return null;
        }

        public async Task<List<Character>> GetCharactersOfUserAsync()
        {
            try
            {
                List<Character> characters = null;

                HttpResponseMessage response = await httpClient.GetAsync(GET_CHARACTER_OF_USER_ENDPOINT + UserId);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    characters = JsonConvert.DeserializeObject<List<Character>>(jsonContent);
                }
                return characters;
            } 
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            return null;

        }
        public async Task<Character> PostRandomCharacter()
        {
            HttpResponseMessage response = await httpClient.PostAsync(POST_RANDOM_CHARACTER + UserId, null);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Character>(jsonContent);
            }
            return null;
        }
        public async Task<SpawnPoint> GetSpawnPointAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_SPAWN_POINT + id);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SpawnPoint>(jsonContent);
            }
            return null;
        }
        public async Task<HttpResponseMessage> Fight(int gameId, int characterId, int ingameMonsterId, int damage)
        {
            HttpResponseMessage response = await httpClient.PostAsync(string.Format(FIGHT,gameId, characterId, ingameMonsterId, damage), null);

            return response;
            }

        public async Task PostCharacterToGame(int characterId, int gameId)
        {
            await httpClient.PostAsync(string.Format(ADD_CHARACTER_To_GAME,characterId,gameId), null);
            
        }

        public async Task<LocalisationPlayer> GetLocalisationPlayer(int characterId, int gameId)
        {
            HttpResponseMessage response = await httpClient.GetAsync(string.Format(GET_LOCATION_OF_PLAYER, gameId, characterId));

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LocalisationPlayer>(jsonContent);
            }
            return null;
        }

        public async Task DeleteCharacter(int iCharacter)
        {
            HttpResponseMessage r = await httpClient.DeleteAsync(DELETE_CHARACTER + iCharacter);

        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_CHARACTER_ENDPOINT + id);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Character>(jsonContent);
            }
            return null;
        }

        public async Task<Class> GetClassByNameAsync(string name)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_CLASS_BY_NAME + name);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Class>(jsonContent);
            }
            return null;
        }

        public async Task<Weapon> GetWeaponAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_WEAPON + id);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Weapon>(jsonContent);
            }
            return null;
        }

        public async Task<Armor> GetArmorAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_ARMOR + id);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Armor>(jsonContent);
            }
            return null;
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            string serializedCharacter = JsonConvert.SerializeObject(character);
            StringContent content = new StringContent(serializedCharacter, Encoding.UTF8, "application/json");

            var response  = await httpClient.PutAsync(PUT_CHARACTER + character.Id, content);
        }
        public async Task UpdateInventoryBoxAsync(InventoryBox inventoryBox)
        {
            string serializedinvBox = JsonConvert.SerializeObject(inventoryBox);
            StringContent content = new StringContent(serializedinvBox, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(PUT_INVENTORY_BOX + inventoryBox.Id, content);
        }

        public async Task<List<InventoryBox>> GetInventoryAsync(int id)
        {
            try
            {
                List<InventoryBox> inventory;

                HttpResponseMessage response = await httpClient.GetAsync(string.Format(GET_INVENTORY, id));

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    inventory = JsonConvert.DeserializeObject<List<InventoryBox>>(jsonContent);
                    return inventory;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;


        }

        public async Task<List<Game>> GetGamesAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_GAMES);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Game>>(jsonContent);
            }
            return null;
        }

        public async Task<int> GetDice10()
        {
            HttpResponseMessage response = await httpClient.GetAsync(GET_DICE_10);

            string jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(jsonContent);
        }

    }
}

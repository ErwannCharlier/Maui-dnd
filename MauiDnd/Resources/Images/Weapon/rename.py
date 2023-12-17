import os

def rename_files_in_folders(parent_folder):
    # Liste de tous les dossiers dans le dossier parent
    folders = [f for f in os.listdir(parent_folder) if os.path.isdir(os.path.join(parent_folder, f))]

    for folder_name in folders:
        folder_path = os.path.join(parent_folder, folder_name)

        # Liste de tous les fichiers dans le dossier
        files = [f for f in os.listdir(folder_path) if os.path.isfile(os.path.join(folder_path, f))]

        # Renommer chaque fichier dans le dossier
        for index, file_name in enumerate(files):
            file_path = os.path.join(folder_path, file_name)

            # Générer le nouveau nom de fichier
            modified_string = ''.join(char for char in folder_name if not (char.isdigit() or char == '-'))

            new_file_name = f"{chr(ord('a') + index)}({modified_string}).jpeg"

            # Construire le nouveau chemin du fichier
            new_file_path = os.path.join(folder_path, new_file_name)

            # Renommer le fichier
            os.rename(file_path, new_file_path)

if __name__ == "__main__":
    # Remplacez 'chemin_du_dossier_parent' par le chemin du dossier contenant les dossiers à traiter
    chemin_du_dossier_parent = r'C:\Users\Erwann\Projet\BingImageCreator\src\End'
    rename_files_in_folders(chemin_du_dossier_parent)

using MauiDnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDnd.ViewModel
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<InventoryBox> _equippedInventoryBoxs;
        private List<InventoryBox> _unequippedInventoryBoxs;

        public List<InventoryBox> EquippedInventoryBoxs
        {
            get { return _equippedInventoryBoxs; }
            set
            {
                _equippedInventoryBoxs = value;
                OnPropertyChanged(nameof(EquippedInventoryBoxs));
            }
        }

        public List<InventoryBox> UnequippedInventoryBoxs
        {
            get { return _unequippedInventoryBoxs; }
            set
            {
                _unequippedInventoryBoxs = value;
                OnPropertyChanged(nameof(UnequippedInventoryBoxs));
            }
        }

        public InventoryViewModel(List<InventoryBox> equippedInventoryBoxs, List<InventoryBox> unequippedInventoryBoxs)
        {
            EquippedInventoryBoxs = equippedInventoryBoxs;
            UnequippedInventoryBoxs = unequippedInventoryBoxs;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

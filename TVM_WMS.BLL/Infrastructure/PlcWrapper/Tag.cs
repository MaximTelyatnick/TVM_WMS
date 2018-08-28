using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.BLL.Infrastructure.PlcWrapper
{
    public enum PlcVar { CurrentWeight, OldWeight, CellNumber, DropoffWindow };

    public class Tag
    {
        private PlcVar _itemProp;
        public PlcVar ItemProp
        {
            get { return _itemProp; }
            set { _itemProp = value; }
        }

        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private object _itemValue;
        public object ItemValue
        {
            get { return _itemValue; }
            set { _itemValue = value; }
        }

        public Tag()
        {

        }
                
        public Tag(PlcVar itemProp, string itemName, object itemValue)
        {
            this.ItemProp = itemProp;
            this.ItemName = itemName;
            this.ItemValue = itemValue;
        }

    }
}

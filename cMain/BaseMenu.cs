using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace cMenu
{
    abstract public class BaseMenu : List<string>
    {
        public ConsoleColor highLightText { get; set; }
        public int selectedItem { get; set; }
        protected bool NumberLines { get; set; }
        protected bool CenterMenu { get; set; }



        abstract public void AddItems(string[] listInput);

        abstract protected void OutPut();

        abstract protected void ColorSelectText(string menuSelect);

        abstract public void IncrementList();//down key

        abstract public void DecrementList();// up key

        


    }
}

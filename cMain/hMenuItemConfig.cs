using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cMenu.Events;
using System.Threading.Tasks;

namespace cMenu
{
    public class hMenuItemConfig : BaseMenu
    {

        public event EventHandler<MenuItemChangedEventArgs> SelectionChange;
        private int i, count = 1;
        private char menuSep;
        private ConsoleColor sepColor;

        public hMenuItemConfig()
        {
            base.highLightText = ConsoleColor.Cyan;
            base.NumberLines = false;
            menuSep = '\0';
            sepColor = ConsoleColor.White;
        }

        public hMenuItemConfig(ConsoleColor hiLight)
        {
            base.highLightText = hiLight;
            base.NumberLines = false;
            menuSep = '\0';
            sepColor = ConsoleColor.White;
        }

        public hMenuItemConfig(ConsoleColor hiLight,bool numberLines)
        {
            base.highLightText = hiLight;
            base.NumberLines = numberLines;
            menuSep = '\0';
            sepColor = ConsoleColor.White;
        }

        public hMenuItemConfig(ConsoleColor hiLight, bool numberLines,char charSeparator)
        {
            base.highLightText = hiLight;
            base.NumberLines = numberLines;
            menuSep = charSeparator;
            sepColor = ConsoleColor.White;
        }

        public hMenuItemConfig(ConsoleColor hiLight,bool numberLines, char charSeparator, 
            ConsoleColor separateColor)
        {
            base.highLightText = hiLight;
            base.NumberLines = numberLines;
            menuSep = charSeparator;
            sepColor = separateColor;
        }

        private void Separator()
        {
            Console.ForegroundColor = sepColor;
            if(menuSep != '\0')
                Console.Write(" {0} ",menuSep);
            Console.ResetColor();
        }

        public override void AddItems(string[] listInput)
        {
            foreach (var item in listInput)
            {
                this.Add(item);
            }
            OutPut();
        }

        protected override void OutPut()
        {
            Console.Clear();

            for ( i = 0; i < this.Count; i++)
            {
                if (i == 0)
                    Separator();
                if (i == selectedItem)
                {
                    ColorSelectText(this[i]);
                }
                else
                {
                    if (NumberLines)
                    {

                        Console.Write(i + 1 + ". ");
                    }
                    Console.Write(this[i]);
                    Console.Write(" ");
                    Separator();
                }

            }

        }

        protected override void ColorSelectText(string menuSelect)
        {
            Console.ForegroundColor = highLightText;
            if (NumberLines)
            {
                Console.Write(i + 1 + ". ");
            }
            Console.Write(menuSelect);
            Console.Write(" ");
            Console.ResetColor(); 
           Separator();
        }


        public override void IncrementList()//down key
        {
            selectedItem++;
            if (selectedItem >= this.Count)
                selectedItem = 0;
            
            MenuItemChangedEventArgs args = new MenuItemChangedEventArgs();
            args.DateAndTime = DateTime.Now;
            args.ChangedCount = count++;
            OnChange(args);

            OutPut();
        }

        public override void DecrementList()// up key
        {
            selectedItem--;
            if (selectedItem < 0)
                selectedItem = this.Count - 1;

            MenuItemChangedEventArgs args = new MenuItemChangedEventArgs();
            args.DateAndTime = DateTime.Now;
            args.ChangedCount = count++;
            OnChange(args);

            OutPut();
        }

       
        private void OnChange(MenuItemChangedEventArgs e)
        {
            Delegates.SelectionChangeHandle = SelectionChange;
            if (Delegates.SelectionChangeHandle != null)
                Delegates.SelectionChangeHandle(this, e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cMenu.Events;
using System.Threading.Tasks;

namespace cMenu
{
    public class vMenuItemConfig : BaseMenu
    {
      
        public event EventHandler<MenuItemChangedEventArgs> SelectionChange;
        private int i = 0, count = 1;

        public vMenuItemConfig()
        {
            base.highLightText = ConsoleColor.Cyan;
            base.NumberLines = false;
            base.CenterMenu = false;
        }

        public vMenuItemConfig(ConsoleColor hiLight)
        {
            base.highLightText = hiLight;
            base.NumberLines = false;
            base.CenterMenu = false;
        }

        public vMenuItemConfig(ConsoleColor hiLight, bool numberLines)
        {
            base.highLightText = hiLight;
            base.NumberLines = numberLines;
            base.CenterMenu = false;
        }

        public vMenuItemConfig(ConsoleColor hiLight, bool numberLines, bool centerText)
        {
            base.highLightText = hiLight;
            base.NumberLines = numberLines;
            base.CenterMenu = centerText;
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
            
            for (i = 0; i < this.Count; i++)
            {
                if (i == selectedItem)
                {
                    ColorSelectText(this[i]);
                }
                else
                {
                    if (NumberLines)
                    {
                        if (CenterMenu)
                            Console.SetCursorPosition(((Console.WindowWidth) / 2) - 7, Console.CursorTop);
                        Console.Write(i + 1 + ". ");  
                    }
                    if (CenterMenu)
                        Console.SetCursorPosition(((Console.WindowWidth) / 2) - 5, Console.CursorTop);
                    Console.WriteLine(this[i]);
                }

            }

        }

        protected override void ColorSelectText(string menuSelect)
        {
            Console.ForegroundColor = highLightText;
            if (NumberLines)
            {
                if (CenterMenu)
                    Console.SetCursorPosition(((Console.WindowWidth) / 2) - 7, Console.CursorTop);
                Console.Write(i + 1 + ". ");
               
            }
            if (CenterMenu)
                Console.SetCursorPosition(((Console.WindowWidth) / 2) - 5, Console.CursorTop);
            Console.WriteLine(menuSelect);
            Console.ResetColor();
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

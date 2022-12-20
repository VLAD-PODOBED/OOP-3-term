using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    class TextEditor
    {
        public void CreateCode() => Console.WriteLine("Написание кода");
        public void Save() => Console.WriteLine("Сохранение кода");
    }
    class Compiller
    {
        public void Compile() => Console.WriteLine("Компиляция приложения");
    }
    class CLR
    {
        public void Execute() => Console.WriteLine("Выполнение приложения");
        public void Finish() => Console.WriteLine("Завершение работы приложения");
    }

    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor textEditor, Compiller compiller, CLR clr)
        {
            this.textEditor = textEditor;
            this.compiller = compiller;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop() => clr.Finish();
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}

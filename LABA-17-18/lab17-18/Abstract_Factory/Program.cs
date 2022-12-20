using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();
        }
    }

    abstract class Weapon       //абстрактный класс - книги
    {
        public abstract void Hit();
    }

    abstract class Movement     // абстрактный класс подписка
    {
        public abstract void Move();
    }


    class Arbalet : Weapon      // класс кто=то
    {
        public override void Hit() => Console.WriteLine("Читает");
    }
    class Sword : Weapon        // класс открытие
    {
        public override void Hit() => Console.WriteLine("Открывает");
    }
    class FlyMovement : Movement // движение удаление
    {
        public override void Move() => Console.WriteLine("Удаляет");
    }
    class RunMovement : Movement // движение - подписывание
    {
        public override void Move() => Console.WriteLine("Подписываемся");
    }
    abstract class HeroFactory  // класс абстрактной фабрики
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    class ElfFactory : HeroFactory // Фабрика создания 
    {
        public override Movement CreateMovement() => new FlyMovement();
        public override Weapon CreateWeapon() => new Arbalet();
    }
    class VoinFactory : HeroFactory // Фабрика создания 
    {
        public override Movement CreateMovement() => new RunMovement();
        public override Weapon CreateWeapon() => new Sword();
    }
    class Hero              // клиент 
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run() => movement.Move();
        public void Hit() => weapon.Hit();
    }
}

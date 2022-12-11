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

    abstract class Weapon       //абстрактный класс - оружие
    {
        public abstract void Hit();
    }

    abstract class Movement     // абстрактный класс движение
    {
        public abstract void Move();
    }


    class Arbalet : Weapon      // класс арбалет
    {
        public override void Hit() => Console.WriteLine("Стреляем из арбалета");
    }
    class Sword : Weapon        // класс меч
    {
        public override void Hit() => Console.WriteLine("Бьем мечом");
    }
    class FlyMovement : Movement // движение полета
    {
        public override void Move() => Console.WriteLine("Летим");
    }
    class RunMovement : Movement // движение - бег
    {
        public override void Move() => Console.WriteLine("Бежим");
    }
    abstract class HeroFactory  // класс абстрактной фабрики
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    class ElfFactory : HeroFactory // Фабрика создания летящего героя с арбалетом
    {
        public override Movement CreateMovement() => new FlyMovement();
        public override Weapon CreateWeapon() => new Arbalet();
    }
    class VoinFactory : HeroFactory // Фабрика создания бегущего героя с мечом
    {
        public override Movement CreateMovement() => new RunMovement();
        public override Weapon CreateWeapon() => new Sword();
    }
    class Hero              // клиент - сам супергерой
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

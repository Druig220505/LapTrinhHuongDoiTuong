using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT02
{
    class ProgramBT02
    {
        class Account
        {
            private string id;
            private string name;
            private int balance;
            public Account(string id, string name, int balance)
            {
                this.id = id;
                this.name = name;
                this.balance = balance;
            }
            public string getID()
            {
                return id;
            }
            public string getName()
            {
                return name;
            }
            public int getBalance()
            {
                return balance;
            }
            public void Credit(int amount)
            {
                if (amount > 0)
                    balance += amount;
            }
            public void Debit(int amount)
            {
                if (amount <= balance)
                    balance -= amount;
                else
                    Console.WriteLine("Số tiền vượt quá mức qui định!");
            }
            public void TranferTo(Account acc, int amount)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    acc.balance += amount;
                }
                else
                    Console.WriteLine("Số tiền vượt quá mức qui định!");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------");
            Console.Write("Nhập id của bạn: ");
            string id = Console.ReadLine();
            Console.Write("Nhập tên của bạn: ");
            string name = Console.ReadLine();
            Console.Write("Nhập số tiền trong tài khoản của bạn: ");
            int balance = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------------------------------------------");
            Account my = new Account(id, name, balance);
            Console.Write("Nhập id bạn của bạn: ");
            string id1 = Console.ReadLine();
            Console.Write("Nhập tên bạn của bạn: ");
            string name1 = Console.ReadLine();
            Console.Write("Nhập số tiền trong tài khoản bạn của bạn: ");
            int balance1 = int.Parse(Console.ReadLine());
            Account myFriend = new Account(id1, name1, balance1);
            Console.WriteLine("---------------------------------------------");
            //Thông tin ban đầu
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Thông tin ban đầu của 2 tài khoản");
            Console.WriteLine("MyAccount: [ id:{0}, name:{1}, balance:{2} ] ",
                my.getID(), my.getName(), my.getBalance());
            Console.WriteLine("MyFriendAccount: [ id:{0}, name:{1}, balance:{2} ] ",
             myFriend.getID(), myFriend.getName(), myFriend.getBalance());
            Console.WriteLine("***********************************************************");
            //Thực hiện giao dịch
            int amount = 0;
            //Rút tiền
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************************************");
            Console.Write("Nhập số tiền bạn muốn rút: ");
            amount = int.Parse(Console.ReadLine());
            my.Debit(amount);
            //Chuyển khoản
            Console.Write("Nhập số tiền bạn muốn chuyển khoản: ");
            amount = int.Parse(Console.ReadLine());
            my.TranferTo(myFriend, amount);
            Console.WriteLine("***********************************************************");
            //Sau khi giao dịch
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Thông tin sau khi thực hiện giao dịch của 2 tài khoản");
            Console.WriteLine("MyAccount: [ id:{0}, name:{1}, balance:{2} ] ",
                my.getID(), my.getName(), my.getBalance());
            Console.WriteLine("MyFriendAccount: [ id:{0}, name:{1}, balance:{2} ] ",
             myFriend.getID(), myFriend.getName(), myFriend.getBalance());
            Console.WriteLine("***********************************************************");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT03
{
    class PhanSo
    {
        private int tuso;
        private int mauso;
        public PhanSo()
        {
            tuso = 0;
            mauso = 1;
        }
        public PhanSo(int tuso, int mauso)
        {
            this.tuso = tuso;
            this.mauso = mauso;
        }
        public void setTuso(int tuso)
        {
            this.tuso = tuso;
        }
        public int getTuso()
        {
            return tuso;
        }
        public void setMauso(int mauso)
        {
            this.mauso = mauso;
        }
        public int getMauso()
        {
            return mauso;
        }
        public void toiGian()
        {
            int uscln = TimUSCLN(tuso, mauso);
            tuso = tuso / uscln;
            mauso = mauso / uscln;
        }
        private int TimUSCLN(int a, int b)
        {
            int x = Math.Abs(a);
            int y = Math.Abs(b);
            while (x != y)
            {
                if (x > y)
                    x = x - y;
                else
                    y = y - x;
            }
            return x;
        }
        public PhanSo cong(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq.tuso = tuso * ps.mauso + ps.tuso * mauso;
            kq.mauso = mauso * ps.mauso;
            return kq;
        }
        public PhanSo tru(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq.tuso = tuso * ps.mauso - ps.tuso * mauso;
            kq.mauso = mauso * ps.mauso;
            return kq;
        }
        public PhanSo nhan(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq.tuso = tuso * ps.tuso;
            kq.mauso = mauso * ps.mauso;
            return kq;
        }
        public PhanSo chia(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq.tuso = tuso * ps.mauso;
            kq.mauso = mauso * ps.tuso;
            return kq;
        }
    }
    internal class ProgramBT03
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CauA();
            CauB();
            
        }
        static void CauA()
        {
            PhanSo p1 = new PhanSo();
            Console.WriteLine("Nhập thông tin phân số thứ 1:");
            Console.Write("Nhập tử số: ");
            int tuso = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số: ");
            int mauso = int.Parse(Console.ReadLine());
            p1.setTuso(tuso);
            p1.setMauso(mauso);
            p1.toiGian();
            Console.WriteLine("Nhập thông tin phân số thứ 2:");
            Console.Write("Nhập tử số: ");
            tuso = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số: ");
            mauso = int.Parse(Console.ReadLine());
            PhanSo p2 = new PhanSo(tuso, mauso);
            p2.toiGian();
            //tổng
            PhanSo tong = p1.cong(p2);
            Console.WriteLine("Tổng 2 phân số: PS1[{0}/{1}], PS2[{2}/{3}] = KQ[{4}/{5}]",
                p1.getTuso(), p1.getMauso(), p2.getTuso(), p2.getMauso(), tong.getTuso(), tong.getMauso());
            //hiệu
            PhanSo hieu = p1.tru(p2);
            Console.WriteLine("Hiệu 2 phân số: PS1[{0}/{1}], PS2[{2}/{3}] = KQ[{4}/{5}]",
                p1.getTuso(), p1.getMauso(), p2.getTuso(), p2.getMauso(), hieu.getTuso(), hieu.getMauso());
            //tích
            PhanSo tich = p1.nhan(p2);
            Console.WriteLine("Tích 2 phân số: PS1[{0}/{1}], PS2[{2}/{3}] = KQ[{4}/{5}]",
                p1.getTuso(), p1.getMauso(), p2.getTuso(), p2.getMauso(), tich.getTuso(), tich.getMauso());
            //thương
            PhanSo thuong = p1.chia(p2);
            Console.WriteLine("Thương 2 phân số: PS1[{0}/{1}], PS2[{2}/{3}] = KQ[{4}/{5}]",
                p1.getTuso(), p1.getMauso(), p2.getTuso(), p2.getMauso(), thuong.getTuso(), thuong.getMauso());
        }
        static void CauB()
        {
            Console.WriteLine("Tính toán dãy phân số");
            Console.Write("Nhập vào số nguyên dương: ");
            int n = int.Parse(Console.ReadLine());

            PhanSo s = new PhanSo(0, 1);
            for (int i = 1; i <= n; i++)
            {
                s = s.cong(new PhanSo(1, i));
            }
            s.toiGian();
            Console.WriteLine("Kết quả dãy phân số: 1+ 1/2 + 1/3 +...+ 1/n = {0}/{1}", s.getTuso(), s.getMauso());

            Console.ReadLine();
        }
    }
}

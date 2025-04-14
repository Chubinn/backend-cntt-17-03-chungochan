using System;

public class PhanSo
{
    public int Tu { get; set; }
    public int Mau { get; set; }

    public PhanSo()
    {
        Tu = 0;
        Mau = 1;
    }

    public PhanSo(int tu, int mau)
    {
        Tu = tu;
        Mau = mau == 0 ? 1 : mau;
        RutGon();
    }

    public void NhapPhanSo()
    {
        Console.Write("Nhập tử số: ");
        Tu = int.Parse(Console.ReadLine());

        Console.Write("Nhập mẫu số: ");
        Mau = int.Parse(Console.ReadLine());

        if (Mau == 0)
        {
            Console.WriteLine("Mẫu số không được bằng 0. Gán mẫu số = 1.");
            Mau = 1;
        }

        RutGon();
    }

    public void RutGon()
    {
        int ucln = UCLN(Math.Abs(Tu), Math.Abs(Mau));
        Tu /= ucln;
        Mau /= ucln;

        if (Mau < 0)
        {
            Tu = -Tu;
            Mau = -Mau;
        }
    }

    private int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }

    public PhanSo Cong(PhanSo ps)
    {
        int tuMoi = this.Tu * ps.Mau + ps.Tu * this.Mau;
        int mauMoi = this.Mau * ps.Mau;
        return new PhanSo(tuMoi, mauMoi);
    }

    public override string ToString()
    {
        return $"{Tu}/{Mau}";
    }
}


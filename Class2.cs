using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<PhanSo> danhSachPhanSo = new List<PhanSo>();

        Console.Write("Nhập số lượng phân số: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập phân số thứ {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.NhapPhanSo();
            danhSachPhanSo.Add(ps);
        }

        PhanSo tong = new PhanSo(0, 1);
        foreach (var ps in danhSachPhanSo)
        {
            tong = tong.Cong(ps);
        }

        Console.WriteLine("Tổng các phân số là: " + tong);
    }
}

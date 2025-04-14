using System;
using System.Collections.Generic;

abstract class Hinh
{
    public abstract double TinhChuVi();
    public abstract double TinhDienTich();
}

class HinhTron : Hinh
{
    public double BanKinh { get; set; }

    public HinhTron(double r)
    {
        BanKinh = r;
    }

    public override double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    public override double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }
}

class HinhVuong : Hinh
{
    public double Canh { get; set; }

    public HinhVuong(double c)
    {
        Canh = c;
    }

    public override double TinhChuVi()
    {
        return 4 * Canh;
    }

    public override double TinhDienTich()
    {
        return Canh * Canh;
    }
}

class HinhChuNhat : Hinh
{
    public double Dai { get; set; }
    public double Rong { get; set; }

    public HinhChuNhat(double dai, double rong)
    {
        Dai = dai;
        Rong = rong;
    }

    public override double TinhChuVi()
    {
        return 2 * (Dai + Rong);
    }

    public override double TinhDienTich()
    {
        return Dai * Rong;
    }
}

class HinhTamGiac : Hinh
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public HinhTamGiac(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Ba cạnh không hợp lệ để tạo tam giác.");
        A = a;
        B = b;
        C = c;
    }

    public override double TinhChuVi()
    {
        return A + B + C;
    }

    public override double TinhDienTich()
    {
        double p = TinhChuVi() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C)); // công thức Heron
    }
}

class Program
{
    static void Main()
    {
        List<Hinh> danhSachHinh = new List<Hinh>();

        // Thêm các hình mẫu (bạn có thể thay thế bằng nhập từ người dùng nếu muốn)
        danhSachHinh.Add(new HinhTron(3));
        danhSachHinh.Add(new HinhVuong(4));
        danhSachHinh.Add(new HinhChuNhat(5, 2));
        danhSachHinh.Add(new HinhTamGiac(3, 4, 5));

        double tongChuVi = 0;
        double tongDienTich = 0;

        Console.WriteLine("Danh sách các hình và thông tin:");
        foreach (var hinh in danhSachHinh)
        {
            Console.WriteLine($"- Chu vi: {hinh.TinhChuVi():0.00}, Diện tích: {hinh.TinhDienTich():0.00}");
            tongChuVi += hinh.TinhChuVi();
            tongDienTich += hinh.TinhDienTich();
        }

        Console.WriteLine($"\nTổng chu vi: {tongChuVi:0.00}");
        Console.WriteLine($"Tổng diện tích: {tongDienTich:0.00}");
    }
}

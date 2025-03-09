# Retail Cashier App

Aplikasi kasir ritel modern dengan antarmuka responsif dan fitur lengkap untuk transaksi cepat, dibangun menggunakan C# .NET Framework 4.7.2 dan Guna UI Controls.

## Fitur Utama

### 💵 Operasi Kasir
- Sistem POS (Point of Sale) dengan grid transaksi dinamis
- Pencarian produk instan via:
  - Barcode scanner (USB/Bluetooth)
  - Keyboard input
  - Pencarian fuzzy (nama sebagian)
- Keranjang belanja dengan fitur:
  - Tambah/Ubah/Jumlah item
  - Diskon bertingkat (item & transaksi)
  - Pajak terpisah
  - Split payment (multi-metode pembayaran)
- Cetak struk thermal otomatis dengan footer custom

### 🛍 Manajemen Transaksi
- History transaksi 7 hari terakhir
- Void transaksi dengan otorisasi PIN
- Retur barang dengan receipt lookup
- Hold transaction (simpan sementara transaksi)
- Quick payment preset (Rp50.000, Rp100.000, dll)

### 📊 Antarmuka Kasir
- UI responsif dengan dark/light mode
- Keyboard shortcut untuk operasi cepat:
  - F1: Buka laci kasir
  - F2: Pindai barcode
  - F3: Bayar tunai
  - F4: Bayar kartu
- Tampilan real-time:
  - Total belanja
  - Jumlah item
  - Kembalian
- Notifikasi stok hampir habis

## Teknologi

### 🖥 Frontend
- **.NET Framework 4.7.2**
- **Guna UI Controls**:
  - Guna2DataGridView
  - Guna2TextBox
  - Guna2GradientButton
  - Guna2MessageDialog
- Bunifu UI (untuk animasi)
- FontAwesome 5.15.4

### ⚙ Backend
- SQL Server 2019
- Dapper ORM
- Entity Framework 6.4.4
- Thermal printer library (ESC/POS)

### 🧩 Integrasi
- Barcode scanner (USB HID)
- Cash drawer (USB/RS-232)
- Customer display (LCD/LED)
- Payment gateway (OVO/DANA simulator)

## Persyaratan Sistem

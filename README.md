# 🛒 E-Commerce Console App (C#)

This is a simple console-based e-commerce system built with C#.  
It allows users to add products to a cart, remove expired items, calculate totals, handle shipping, and simulate a checkout process.

---

## ✨ Features

- ✅ Product management with name, price, and quantity
- 📦 Supports expirable items (e.g., Cheese, Biscuits)
- 🚚 Handles shippable products with weight-based shipping cost
- 🛒 Shopping cart functionality
- 💳 Checkout with subtotal, shipping fee, and remaining balance
- ❌ Prevents checkout if:
  - The cart is empty
  - Any item is expired or out of stock
  - Balance is insufficient

---

## 🧱 Product Types

| Product            | Expirable | Shippable | Weight |
|--------------------|-----------|-----------|--------|
| Cheese             | ✅        | ✅        | per KG |
| Biscuits           | ✅        | ✅        | per Box |
| TV                 | ❌        | ✅        | per Unit |
| Mobile Scratch Card| ❌        | ❌        | N/A |

---

## 🧮 Shipping Cost

- 💰 `$5` per `1 kg`
- 🎁 Orders with subtotal **≥ $100** get **free shipping**

---

## 🧑‍💻 Technologies Used

- Language: C#
- Project Type: .NET Console App
- No external packages or database used

---

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/moatazbadr/EcommerceApp1.git
   cd EcommerceApp1
   ```
2. **Run the App**
   ```bash
   dotnet build
    dotnet run
   ```
3. **OutPut sample**
```bash
   ** Shipment notice **
2x Cheese      400g
1x Biscuits    700g
Total package weight 1.1kg

** Checkout receipt **
2x Cheese      200
1x Biscuits    150
----------------------
Subtotal        350
Shipping         30
Amount          380
```

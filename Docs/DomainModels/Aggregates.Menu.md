# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```


```json
{
    "id": "0000000-0000-0000-0000-000000000000",
    "name": "Menu 1",
    "description": "Best Seller",
    "averageRating": 4.5,
    "sections": [
        {
            "id": "0000000-0000-0000-000000000000",
            "name": "Khai vi",
            "description": "Starters",
            "items": [
                {
                    "id": "0000000-0000-0000-000000000000",
                    "name": "Goi Tom Dat",
                    "description": "Mon Khai Vi",
                    "imageUrl": "https://lh3.googleusercontent.com/proxy/WUAz2yMAh0FGYSFFZKtFUjxGqogrZxI_KhEVzDvgBQO08Op3Nq9h4AuF-gCH6jQnBa7FbSgga9Br0zvad8rR6zV9Iq_fYL9wqZ8vvYYLmH_hsKff",
                    "price": 5.99,
                    ""
                }
            ]
        }
    ],
    "hostId": "0000000-0000-0000-000000000000",
    "dinnerIds": [
        "0000000-0000-0000-000000000000", 
        "0000000-0000-0000-000000000000"
        ],
    "menuReviewIds": [
        "0000000-0000-0000-000000000000",
        "0000000-0000-0000-000000000000"
    ],
}

```

const deleteProductFromBasket = (product) => {
    const basket = JSON.parse(sessionStorage.getItem('basket'))
    const index = basket.products.findIndex(p => p.product.productId === product.product.productId)
    basket.payment = basket.payment - product.quantity * product.product.price;
    basket.count = basket.count - product.quantity;
    basket.products.splice(index, 1)
    sessionStorage.setItem('basket', JSON.stringify(basket))
     document.getElementById("items").replaceChildren()
    drawProducts()
}

const changeQuantityPluse = (product) => {
    const basket = JSON.parse(sessionStorage.getItem('basket'))
    const index = basket.products.findIndex(p => p.product.productId === product.product.productId)
    basket.products[index].quantity++;
    basket.count++;
    basket.payment += product.product.price;
    sessionStorage.setItem('basket', JSON.stringify(basket))
    document.getElementById("items").replaceChildren()

    drawProducts()
}
const changeQuantityMinus = (product) => {
    const basket=JSON.parse(sessionStorage.getItem('basket'))
    const index = basket.products.findIndex(p => p.product.productId === product.product.productId)
    if (basket.products[index].quantity == 1) {
        deleteProductFromBasket(product)
    }
    else {
        basket.products[index].quantity--;
        basket.count--;
        basket.payment -= product.product.price;
        sessionStorage.setItem('basket', JSON.stringify(basket))
        document.getElementById("items").replaceChildren()
        drawProducts()
    }
}
const drawProducts = () => {
    const basket = JSON.parse(sessionStorage.getItem("basket")) || [];
    const template = document.getElementById("temp-row");
    basket.products.forEach((product) => {
        const card = template.content.cloneNode(true)
        card.querySelector('img').src = '../Images/' + product.product.imageUrl
        card.querySelector('.description').textContent = product.product.productName
        card.querySelector('.total-price').textContent = "$" + product.product.price
        card.querySelector('.quantityNumber').textContent = product.quantity
        card.querySelector('.delete-btn').addEventListener('click', event => deleteProductFromBasket(product))
        card.querySelector('.plus-btn').addEventListener('click', event => changeQuantityPluse(product))
        card.querySelector('.minus-btn').addEventListener('click', event => changeQuantityMinus(product))

        document.getElementById("items").appendChild(card)
    }
    )
    document.getElementById('totalAmount').textContent = "   $" + basket.payment

}

const placeOrder =async () => {
    const basket = JSON.parse(sessionStorage.getItem("basket"));
    const userId = sessionStorage.getItem("userId");

    if (!basket) {
        alert("the basket is empty continou shopping")
        window.location = 'Products.html'
        return;
    }
    let orderItems = []
    basket.products.forEach(p =>
        orderItems.push( {
            "productId": p.product.productId,
            "quantity": p.quantity
        })
    )

    const order = {
        "orderDate": new Date(),
        "orderSum": basket.payment,
        "userId": userId,
        "orderItems":orderItems
    }
    const responsePost = await fetch('api/Orders', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
    const dataPost = await responsePost.json();

    if (dataPost) {
        sessionStorage.removeItem('basket')
        alert(`Order ${dataPost.orderId} created succesfully`)
        window.location='Products.html'
    }
}
drawProducts()

let categoriesForFilter = []

const showSumOfItems = () => {
    const basket = JSON.parse(sessionStorage.getItem('basket'))
    if (basket) {
        document.getElementById("basket").dataset.afterText = basket.count;
    }
    else {
        document.getElementById("basket").dataset.afterText = "0";

    }
}

const addToBasket = (product) => {
    let basket = sessionStorage.getItem('basket')
    if (!basket) {
        basket = { products: [{ product: product, quantity: 1 }], payment: product.price,count:1 }
        
    }
    else {
        basket = JSON.parse(basket)
        const index = (basket.products).findIndex(p => p.product.productId===product.productId)
        if (index != -1) {
            basket.products[index].quantity = basket.products[index].quantity + 1;
            basket.payment = basket.payment + product.price;
        }
        else {
            basket.products.push({ product: product, quantity: 1 })
            basket.payment = basket.payment + product.price;
        }

        basket.count++;
    }
    sessionStorage.setItem('basket', JSON.stringify(basket))
    showSumOfItems()
}

const drawProducts = (data) => {

    const template = document.getElementById("temp-card")

    data.forEach((product) => { 
        const card = template.content.cloneNode(true)
        card.querySelector('h1').textContent = product.productName
        card.querySelector('.price').textContent = product.price
        card.querySelector('.description').textContent = product.description
        card.querySelector('img').src = '../Images/' + product.imageUrl
        card.querySelector('button').addEventListener('click', event => addToBasket(product))
        document.getElementById("PoductList").appendChild(card)  
    }
    )
  
}

const getAllProducts = async() => {

    const responsePost = await fetch('api/products', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (responsePost.ok) {
        const dataPost = await responsePost.json();
        drawProducts(dataPost);
        const minPriceInput = document.getElementById('minPrice');
        const maxPriceInput = document.getElementById('maxPrice');

        minPriceInput.value = dataPost[0].price;
        maxPriceInput.value = dataPost[dataPost.length - 1].price;

    }
    else {
        alert("errorrrr")
    }

}



const addToFilterCategory = (event, category) => {
    if (event.target.checked) {
        categoriesForFilter.push(category.categoryId)
    }
    else {
        categoriesForFilter.splice(categoriesForFilter.indexOf(category.categoryId),1)
    }
    filterProducts()
}

const filterProducts = async () => {
    const search = document.getElementById('nameSearch').value
    const minPrice = document.getElementById('minPrice').value
    const maxPrice = document.getElementById('maxPrice').value
    const CategoriesId = categoriesForFilter;
  const responsePost = await fetch(`api/products?search=${search}&maxPrice=${maxPrice}&minPrice=${minPrice}&CategoriesId=${CategoriesId}`   , {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const dataPost = await responsePost.json();
    document.getElementById("PoductList").replaceChildren()
    drawProducts(dataPost);
}
const drawCategories = (data) => {
    const template = document.getElementById("temp-category")

    data.forEach((category) => {
        const checkbox = template.content.cloneNode(true)
        checkbox.querySelector('.opt').id = category.categoryId
        checkbox.querySelector('.opt').value = category.categoryName
        checkbox.querySelector('label').for = category.categoryName
        checkbox.querySelector('.OptionName').textContent = category.categoryName
        checkbox.querySelector('.opt').addEventListener('change', event => addToFilterCategory(event,category))

        document.getElementById("categoryList").appendChild(checkbox)


    })
  
}
const getAllCategories = async () => {

    const responsePost = await fetch('api/categories', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const dataPost = await responsePost.json();
    drawCategories(dataPost)
    
}



getAllProducts()
getAllCategories()
showSumOfItems()
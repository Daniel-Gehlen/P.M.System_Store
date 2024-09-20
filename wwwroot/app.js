
document.addEventListener('DOMContentLoaded', function () {
    // Selecionar os elementos da página
    const categoryForm = document.getElementById('categoryForm');
    const categoryNameInput = document.getElementById('categoryName');
    const loadCategoriesButton = document.getElementById('loadCategories');
    const categoryList = document.getElementById('categoryList');
    
    const productForm = document.getElementById('productForm');
    const categoryIdInput = document.getElementById('categoryId');
    const productNameInput = document.getElementById('productName');
    const productPriceInput = document.getElementById('productPrice');
    const productList = document.getElementById('productList');

    // Função para carregar categorias do backend
    async function loadCategories() {
        const response = await fetch('/category');
        const categories = await response.json();
        categoryList.innerHTML = '';
        categories.forEach(category => {
            const li = document.createElement('li');
            li.textContent = `Category ${category.number}: ${category.name}`;
            categoryList.appendChild(li);
        });
    }

    // Evento de submissão do formulário para adicionar categoria
    categoryForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const categoryName = categoryNameInput.value;

        const response = await fetch('/category', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name: categoryName })
        });

        if (response.ok) {
            alert('Category added successfully!');
            categoryNameInput.value = '';
            loadCategories();  // Recarregar as categorias
        } else {
            alert('Failed to add category.');
        }
    });

    // Evento para carregar categorias ao clicar no botão
    loadCategoriesButton.addEventListener('click', loadCategories);

    // Função para carregar produtos de uma categoria
    async function loadProducts(categoryId) {
        const response = await fetch(`/category/${categoryId}/products`);
        const products = await response.json();
        productList.innerHTML = '';
        products.forEach(product => {
            const li = document.createElement('li');
            li.textContent = `Product ${product.number}: ${product.name} - Price: ${product.price}`;
            productList.appendChild(li);
        });
    }

    // Evento de submissão do formulário para adicionar produto
    productForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const categoryId = categoryIdInput.value;
        const productName = productNameInput.value;
        const productPrice = parseFloat(productPriceInput.value);

        const response = await fetch(`/category/${categoryId}/products`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name: productName, price: productPrice })
        });

        if (response.ok) {
            alert('Product added successfully!');
            productNameInput.value = '';
            productPriceInput.value = '';
            loadProducts(categoryId);  // Recarregar os produtos
        } else {
            alert('Failed to add product.');
        }
    });
});
EOL

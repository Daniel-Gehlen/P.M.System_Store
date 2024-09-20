async function fetchCategories() {
    const response = await fetch('/api/category');
    const categories = await response.json();

    const categoryList = document.getElementById('category-list');
    categoryList.innerHTML = '';

    categories.forEach(category => {
        const categoryDiv = document.createElement('div');
        categoryDiv.innerHTML = `<h3>${category.name}</h3>`;
        categoryList.appendChild(categoryDiv);
    });
}

async function addCategory() {
    const categoryName = document.getElementById('categoryName').value;

    await fetch('/api/category', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(categoryName)
    });

    fetchCategories(); // Refresh the list after adding
}

// Initialize
fetchCategories();

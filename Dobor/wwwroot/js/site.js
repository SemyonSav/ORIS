const descriptionNavButton = document.querySelector('#description-btn');
const reviewNavButton = document.querySelector('#reviews-btn');
const description = document.querySelector('.product__reviews__description');
const reviews = document.querySelector('.product__reviews__reviews');

descriptionNavButton.addEventListener("click", event => {
    descriptionNavButton.className = "product__reviews__nav-button product__reviews__nav-button--active";
    reviewNavButton.className = "product__reviews__nav-button";
    description.style.display = "block";
    reviews.style.display = "none";
});

reviewNavButton.addEventListener("click", event => {
    reviewNavButton.className = "product__reviews__nav-button product__reviews__nav-button--active";
    descriptionNavButton.className = "product__reviews__nav-button";
    reviews.style.display = "block";
    description.style.display = "none";
});


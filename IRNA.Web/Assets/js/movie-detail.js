// init movie-imagesslider:
const movieImagesSlider = new Swiper(".movie-images-slider", {
    slidesPerView: 3.3,
    spaceBetween: 5,
    loop: true,
    autoplay: {
      delay: 2000,
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    breakpoints: {
      328: { slidesPerView: 3.3, spaceBetween: 5 },
      768: { slidesPerView: 5, spaceBetween: 5 },
      992: { slidesPerView: 7, spaceBetween: 10 },
    }
  });
  // suggested movies slider:
const suggestedMovieSlider = new Swiper(".suggested-movies-slider", {
  slidesPerView: 8,
  spaceBetween: 10,
  loop: true,
  autoplay: {
    delay: 2000,
  },
  breakpoints: {
    328: { slidesPerView: 3.1, spaceBetween: 5 },
    768: { slidesPerView: 3.1, spaceBetween: 5 },
    992: { slidesPerView: 8, spaceBetween: 10 },
  },
});
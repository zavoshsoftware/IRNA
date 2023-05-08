// init movie-imagesslider:
const movieImagesSlider = new Swiper(".movie-images-slider", { 
    spaceBetween: 5,
    slidesPerGroup: 1,
    loop: false,
    autoplay: {
      delay: 2000,
    },
    pagination: {
      el: ".swiper-pagination",
      clickable: false,
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    breakpoints: {
      328: { slidesPerView: 3.3, spaceBetween: 5 },
      768: { slidesPerView: 5, spaceBetween: 5 },
      992: { slidesPerView: 7, spaceBetween: 5},
    }
  });
  // suggested movies slider:
const suggestedMovieSlider = new Swiper(".suggested-movies-slider", {
  slidesPerView: 8,
    spaceBetween: 10,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
  loop: true,
  autoplay: {
    delay: 2000,
  } 
});


$(document).ready(() => {

    $('#comment').on('click', () => {
        
        $.post('/Content/sendcomment',
            {
                id: parseInt($('#id').val()), 
                body: $('#body').val() 
            },
            function (data, status) {
                console.log(data.res);
                if (status == 'success') {
                    $('#cmdres').text('نظر شما ثبت شد')
                    $('#body').val('')
                }
            }); 
    });








})
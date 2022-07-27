// init main slider:
const mainSlider = new Swiper(".main-slider", {
    slidesPerView: 1,
    spaceBetween: 10,
    loop: true,
    autoplay: {
        delay: 4000,
    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

// init irna-24 slider:
const irna24Slider = new Swiper(".irna-24-slider", {
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
        328: { slidesPerView: 3, spaceBetween: 5 },
        768: { slidesPerView: 5, spaceBetween: 5 },
        992: { slidesPerView: 7, spaceBetween: 10 },
    },
});
// init adds slider:
const addsSlider = new Swiper(".adds-slider", {
    slidesPerView: 3.1,
    spaceBetween: 10,
    loop: true,
    autoplay: {
        delay: 3000,
    },
    breakpoints: {
        328: { slidesPerView: 1, spaceBetween: 5 },
        768: { slidesPerView: 1, spaceBetween: 5 },
        992: { slidesPerView: 3, spaceBetween: 10 },
    },
});
// latest movies slider:
const latestMovieSlider = new Swiper(".latest-movies-slider", {
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
// init events slider:
const eventsSlider = new Swiper(".events-slider", {
    slidesPerView: 2.1,
    spaceBetween: 5,
    loop: true,
    autoplay: {
        delay: 3000,
    },
    breakpoints: {
        328: { slidesPerView: 3.1, spaceBetween: 5 },
        768: { slidesPerView: 3, spaceBetween: 5 },
        992: { slidesPerView: 4, spaceBetween: 10 },
    },
});
// oskar moviews slider:
const oskarMovieSlider = new Swiper(".oskar-movies-slider", {
    slidesPerView: 3.1,
    spaceBetween: 5,
    loop: true,
    autoplay: {
        delay: 2000,
    },
    breakpoints: {
        328: { slidesPerView: 3.1, spaceBetween: 5 },
        768: { slidesPerView: 5, spaceBetween: 5 },
        992: { slidesPerView: 8, spaceBetween: 10 },
    },
});
// show mobile menu
let menuBtn = $("#menu-btn");
menuBtn.on("click", () => {
    $(".mobile-menu").slideToggle();
});
// show mobile filter
let showFilter = $(".show-filter");
let filter = $("#filter");
showFilter.on("click", () => {
    filter.slideToggle();
    filter.css({ dispay: "flex", "flex-direction": "column", gap: "0.5rem" });
});
//show searchbox
let searchBtn = $("#search-btn");
let searchd = $("#searchd");
let searchm = $("#searchm");
searchBtn.on("click", (e) => {
    let visibled = searchd.attr("data-visible");
    let visiblem = searchm.attr("data-visible");
    if (document.body.clientWidth <= 992) {
        if (visiblem === "false") {
            searchm.slideDown();
            searchm.attr("data-visible", "true"); 
            searchBtn.attr("onclick", "irnasearch('m');");
        } else if (e.target.id !== "search-btn") {
            searchm.slideUp();
            searchm.attr("data-visible", "false");
        } else {
            searchm.attr("data-visible", "false");
            searchm.slideUp();
        }
    } else {
        if (visibled === "false") {
            searchd.css("transform", "scaleX(1)");
            searchd.attr("data-visible", "true");
            searchBtn.attr("onclick", "irnasearch('c');");
        } else {
            searchd.attr("data-visible", "false");
            searchd.css("transform", "scaleX(0)");
        }
    }
});

function irnasearch(device) {
    let searchd = $("#searchd");
    let searchm = $("#searchm");
    if (device == 'm') {
        document.location.href = '/list?q='+searchm.val()
    }
    else {
        document.location.href = '/list?q=' + searchd.val()
    }
}

$(document).ready(() => {
    $('.swiper-slide').filter(function () { //use filter on all .categories
        var txt = $.trim(this.innerHTML); //Get the text of current
        return ($(this).nextAll().filter(function () { //filter all of the proceeding siblings which has the same text
            return $.trim(this.innerHTML) === txt
        }).length); //send true or false (in fact truthy or falsy to ask to hide the current element in question)
    }).hide();
});

/***** buy sub scribtion in menu***** */
let buysublink = document.querySelector("#buy-sub");
let buysub = $(".buy-sub");
buysublink.addEventListener("click", () => {
    if (buysublink.dataset.open === "false") {
        buysub.slideDown();
        buysub.css("display", "flex");
        buysublink.dataset.open = "true";
    } else {
        buysublink.dataset.open = "false";
        buysub.slideUp();
    }
});
document.addEventListener("click", (e) => {
    if (
        !e.target.parentNode.className.includes("buy-sub-con")
    ) {
        buysublink.dataset.open = "false";
        buysub.slideUp();
    }
});














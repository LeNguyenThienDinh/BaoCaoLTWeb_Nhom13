//search
let search = document.querySelector('.search');

document.querySelector('#seach-icon').onclick = () =>{
    search.classList.toggle('active');
    navbar.classList.remove('active');
}


//thanh header
let header = document.querySelector('header');
window.addEventListener('scroll',()=>{
    header.classList.toggle('shadow',window.scrollY>0);
});
//chuyển tiếp giữa menu and search
window.onscroll = () => {
    navbar.classList.remove('active');
    search.classList.remove('active');
}
//menu
let navbar = document.querySelector('.navbar');

document.querySelector('#menu-icon').onclick = () =>{
    navbar.classList.toggle('active');
    search.classList.remove('active');
}


//Hiệu ứng reset
const sr = ScrollReveal({
    distance: '65px',
    duration: 2600,
    delay:450,
    reser: true
});


/*
sr.reveal('.home-text',{delay:200,origin:'top'});
sr.reveal('.home-img',{delay:200,origin:'top'});
sr.reveal('.t-icon',{delay:200,origin:'left'});
sr.reveal('.heading',{delay:50,origin:'bottom'});
sr.reveal('.search-sp',{delay:50,origin:'bottom'});
sr.reveal('.search_tt',{delay:50,origin:'left'});
sr.reveal('.product-container-small',{delay:50,origin:'right'});
sr.reveal('.page-btn',{delay:50,origin:'bottom'});

sr.reveal('.single-product',{delay:50,origin:'bottom'});


sr.reveal('.docquyen-text',{delay:50,origin:'bottom'});
sr.reveal('.docquyen-img',{delay:50,origin:'bottom'});

sr.reveal('.about-text',{delay:50,origin:'bottom'});
sr.reveal('.about-img',{delay:50,origin:'bottom'});

sr.reveal('.product-container',{delay:50,origin:'bottom'});

sr.reveal('.danhgia-container',{delay:50,origin:'bottom'});

sr.reveal('.account-page',{delay:50,origin:'bottom'});

sr.reveal('.cart-page',{delay:50,origin:'bottom'});
sr.reveal('.profile',{delay:50,origin:'bottom'});
*/

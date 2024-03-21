
let wrapper= document.querySelector('.wrapper'),
    signUplink=document.querySelector('.link .signup-link'),
    signInlink=document.querySelector('.link .signin-link');

signUplink.addEventListener('click',()=>{
     wrapper.classList.add('animated-signin');
     wrapper.classList.remove('animated-signup');     
});

signInlink.addEventListener('click',()=>{
    wrapper.classList.add('animated-signup'); 
    wrapper.classList.remove('animated-signin');   
});
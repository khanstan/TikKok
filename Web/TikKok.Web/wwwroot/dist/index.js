new Vue({
    el: '#app',
});

let like = document.getElementById("like");

window.onload = function () {
    like.addEventListener("click",
        function (e) {
            axios.post('/Home/Like', like.getAttribute("data-id") )
                .then(response => this.responseData = response.data)
                .catch(error => { console.log(error) });
        });
};

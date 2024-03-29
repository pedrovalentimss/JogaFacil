﻿window.initMap = (lat, long) => {
    console.log("Acessou initMap");
    var mymap = L.map('mapid').setView([51.505, -0.09], 13);
    if (mymap) {
        console.log("Map encontrado");
    }

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'pk.eyJ1IjoicGVkcm9odnMiLCJhIjoiY2tidTVubWpqMDFrbTJ6bnNoZW9lYm9pbSJ9.yxuYZPNn0hlQ0MoLNZzklQ'
    }).addTo(mymap);

    var marker = L.marker([51.5, -0.09]).addTo(mymap);
}
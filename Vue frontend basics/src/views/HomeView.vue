<script setup>
import DataService from '../services/dataservice';
import { ref,onMounted } from 'vue';

const gyartok = ref([])
const telefonok = ref([])
const valasztott = ref("")
const szinek = ref([])
DataService.getAllGyartok()
    .then(resp => {
        gyartok.value = resp;
    })
    .catch(err => {
        console.log(err);
    })
DataService.getAllTelefonok()
    .then(resp => {
        telefonok.value = resp;
    })
    .catch(err => {
        console.log(err);
    })
onMounted(() => {
    for (let x = 0; x < telefonok.value.length; x++) {
        if (!szinek.value.includes(telefonok.value[x].value.szín)) {
            szinek.value.push(telefonok.value[x].value.szin);
        }
    }
    console.log(szinek.value);
})

        
</script>

<template>
    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 150 30">
        <text x="50%" y="50%" font-size="25" font-weight="bold" font-style="italic" font-family="monospace"
            text-anchor="middle" dominant-baseline="middle">
            <tspan fill="#00CED1">Edu</tspan>
            <tspan fill="#90EE90" dx="-2">Tron</tspan>
        </text>
    </svg>

    <select v-model="valasztott">
        <option  v-for="x in telefonok" id="x">{{ x.nev }}</option>
    </select>

    <ul>
        <h1>{{ valaszott }}</h1>
        <li v-for="szin in szinek">{{ szin }}</li>
    </ul>
</template>

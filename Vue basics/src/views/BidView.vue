<script setup>
import dataservice from '../services/dataservice.js'
import { ref } from 'vue'
import { usePaintingBidStore, } from '../stores/index'

const paintings = ref([])
const bid = ref({})
let error = ref()
const accepted = ref(false)
const aktPainting = usePaintingBidStore()
function asd() {
  console.log(aktPainting.kivPainting);
}
dataservice.getAllCategories()
    .then((resp) => {
      paintings.value = resp.data;
        //console.log(gyartok.value);
    })
    .catch((err) => {
        console.log(err);
    });
    const sendBid = (selectedPainting) => {
    if (accepted.value) {
        bid.value.id = selectedPainting
        console.log(`Az érték: ${vote.value}`);
        dataservice.saveBid(vote.value)
            .then((resp) => {
                alert("OK")
            })
            .catch((err) => {
                error.value = err.response.data.message
                console.log(err);
            });
    }
    else {
        error.value = "Please accept the term of use!"
    }
}

</script>

<template>
  <button class="btn btn-primary" @click="asd()">asd</button>
  <div class="container">
    <h1 class="text-center">Bidding</h1>


    <div class="form col-10 offset-1 col-md-8 offset-md-2 col-lg-6 offset-lg-3 my-4">

      <div class="mb-3">
        <label for="car" class="form-label">Selected painting:</label>
        <div class="text-center">
          <img :src="aktPainting.kivPainting.imageUrl" alt="Place of selected painting" />
        </div>
      </div>

      <div class="mb-3">
        <label for="email" class="form-label">Your e-mail address:</label>
        <input type="text" class="form-control" id="email">
      </div>

      <div class="mb-3">
        <label for="offer" class="form-label">Offer (in HUF):</label>
        <input type="number" class="form-control" id="offer">
      </div>

      <div class="mb-3">
        <input v-model="accepted" type="checkbox" id="acceptedConditions" class="form-check-input">
        <label for="acceptedConditions" class="form-check-label">Accept terms of use</label>
      </div>

      <div class="mb-3 text-center">
        <input type="button" value="Send offer" @click="sendBid(aktPainting.kivPainting.id)" class="btn btn-primary" data-bs-toggle="modal"
          data-bs-target="#successfullBidModal">
      </div>


      <div v-if="error" class="alert alert-danger alert-dismissible fade show" role="alert">
                {{ error }}
                <button type="button" class="btn-close" @click="hibakezelo" aria-label="Close"></button>
            </div>
    </div>

    <div class="modal fade" id="successfullBidModal" tabindex="-1">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header mx-auto">
            <h5 class="modal-title text-center">Your offer has been successfully registered</h5>
          </div>
          <div class="modal-footer mx-auto">
            <a class="btn btn-secondary" href="/">Back to list</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
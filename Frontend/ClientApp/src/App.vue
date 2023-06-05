<script setup lang="ts">
import { onMounted, ref } from 'vue';
import axios from "axios";
import { CubeTypes } from './CubeTypes';

const scramble = ref<string>();
async function getScramble() {
  await axios.get(`/api/scrambles/${CubeTypes.ThreeByThree}`).then(function (response) {
    scramble.value = response.data;
  })
}

onMounted(() => {
  getScramble()
})

</script>

<template>
  <p>{{ scramble }}</p>
</template>

<style scoped></style>

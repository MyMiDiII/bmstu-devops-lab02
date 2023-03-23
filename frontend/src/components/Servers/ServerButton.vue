<template>
  <button class="circle">
    <img v-if="accept" src='@/assets/img/accept.svg' />
    <img v-else src='@/assets/img/reject.svg' />
  </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: "ServerButton",
  props: {
    accept: {
      type: Boolean,
      default: true
    } 
  }
})
</script>

<style scoped>
.circle{
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}
</style>

<template>
    <img v-if="state === 'accepted'" src='../../assets/img/accepted.svg' />
    <img v-else-if="state === 'pending'" src='../../assets/img/pending.svg' />
    <img v-else-if="state === 'rejected'" src='../../assets/img/rejected.svg' />
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: "ServerStatus",
  props: {
    state: {
      type: String,
      default: 'pending'
    } 
  }
})
</script>

<template>
  <div class="blue-text" :style="{fontSize}">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "BlueText",
  components: {},
  props: ['fontSize']
});
</script>

<style scoped>
  .blue-text {
    color: var(--cyan);
    font: "Chakra Petch";
    text-shadow: 0px 0px 10px var(--magenta);
  }
</style>
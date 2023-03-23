<template>
  <div class="pink-text" :style="{ fontSize }">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "PinkText",
  props: {
    fontSize: String,
  },
});
</script>

<style scoped>
.pink-text {
  color: var(--magenta);
  font: "Chakra Petch";
  text-shadow: 0px 0px 20px var(--magenta);
}
</style>

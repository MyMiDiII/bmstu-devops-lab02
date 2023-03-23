<template>
  <div class="wrapper upper-background">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: "UpperBackground"
})
</script>

<style scoped>
.upper-background {
  background: rgba(0, 0, 0, 0.6);
  box-shadow: 0px 0px 60px var(--cyan);
}
</style>

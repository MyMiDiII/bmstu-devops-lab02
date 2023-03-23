<template>
  <button class="button user-patch">
    <img src="../assets/img/user-logo.svg" height="40"/>
    <PinkText fontSize="var(--little-text)">
      <slot></slot>
    </PinkText>
  </Button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from "@/components/Button.vue"
import PinkText from "@/components/PinkText.vue"

export default defineComponent({
  name: "UserPatch",
  components: {
    Button,
    PinkText
  }
})
</script>

<style scoped>
.user-patch {
  gap: 10px;
  background: rgba(0, 0, 0, 0.3);
}
</style>

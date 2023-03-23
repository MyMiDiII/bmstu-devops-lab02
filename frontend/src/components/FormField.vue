<template>
  <div class="form-field">
    <BlueText fontSize="var(--little-text)"><slot></slot></BlueText>
    <InputLine fontSize="var(--tiny-text)" style="text-align: center;"/>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import BlueText from "@/components/BlueText.vue"
import InputLine from "@/components/InputLine.vue"

export default defineComponent({
  name: "FormField",
  components: {
    BlueText,
    InputLine
  },
  props: {}
});
</script>

<style scoped>
  .form-field {
    justify-content: center;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap:10px;
  }
</style>

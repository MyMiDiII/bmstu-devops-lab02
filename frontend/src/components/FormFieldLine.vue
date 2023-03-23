<template>
  <div class="form-field-line">
    <BlueText fontSize="var(--little-text)"><slot></slot></BlueText>
    <InputLine fontSize="var(--tiny-text)"/>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import BlueText from "@/components/BlueText.vue"
import InputLine from "@/components/InputLine.vue"

export default defineComponent({
  name: "FormFieldLine",
  components: {
    BlueText,
    InputLine
  },
  props: {}
});
</script>

<style scoped>
  .form-field-line {
    display: flex;
    gap: 5px;
    align-items: baseline;
  }
</style>

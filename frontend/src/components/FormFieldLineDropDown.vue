<template>
  <div class="form-field-line-drop-down">
    <BlueText fontSize="var(--little-text)"><slot></slot></BlueText>
    <InputLine fontSize="var(--tiny-text)"/>
    <DropDownButton size=15px />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import BlueText from "@/components/BlueText.vue"
import InputLine from "@/components/InputLine.vue"
import DropDownButton from "@/components/DropDownButton.vue"

export default defineComponent({
  name: "FormFieldLine",
  components: {
    BlueText,
    InputLine,
    DropDownButton
  },
  props: {}
});
</script>

<style scoped>
  .form-field-line-drop-down {
    display: flex;
    gap: 5px;
    align-items: baseline;
  }
</style>

<template>
  <div class="form-field">
    <BlueText fontSize="var(--little-text)"><slot></slot></BlueText>
    <Select fontSize="var(--tiny-text)" style="text-align: center;"/>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import BlueText from "@/components/BlueText.vue"
import Select from "@/components/Select.vue"

export default defineComponent({
  name: "FormField",
  components: {
    BlueText,
    Select
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
    gap:15px;
  }
</style>

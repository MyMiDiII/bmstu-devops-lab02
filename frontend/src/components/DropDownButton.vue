<template>
    <button class="drop-down-button" aria-pressed="drop-down">
        <img
            class="drop-down" 
            src="@/assets/img/dropdown-btn.svg"
            alt="drop-down"
        />
    </button>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "DropDownButton",
  components: {},
  props: {
    size: String,
    rotateAngle: String
  }
});
</script>

<style scoped>
  .drop-down {
    width: v-bind(size);
    height: v-bind(size);
    filter: drop-shadow(0px 0px 10px var(--magenta));
    transform: rotate(v-bind(rotateAngle));
  }

  .drop-down-button {
    background: none;
    color: inherit;
    border: none;
    padding: 0;
    font: inherit;
    cursor: pointer;
    outline: inherit;
  }
</style>


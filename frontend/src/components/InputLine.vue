<template>
    <input v-model="data" v-if="name == 'password'" type="password" class="input-line" :style="{fontSize}">
    <input v-model="data" v-else class="input-line" :style="{fontSize}">
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "InputLine",
  data () {
    return {
      data: "",
    }
  },
  components: {},
  props: ['name', 'fontSize'],
  watch: { 
    data: function() {
      console.log(this.name, this.data);
      this.$emit(this.name, this.data);
    }
  },
  // mounted () {
  //   this.data = this.setData;
  //   console.log("Input Get:", this.setData);
  // },
});
</script>

<style scoped>
  .input-line {
    background: transparent;
    border: none;
    border-bottom: 2px solid var(--cyan);
    text-align: center;
    /* width: 231px;
    height: 35px; */
    filter: drop-shadow(0px 0px 10px var(--magenta));
    font: "Chakra Petch";
    color: var(--cyan);
  }
</style>


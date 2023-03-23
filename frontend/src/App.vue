<template>
  <Background>
    <notifications position="top center" classes="notify" width="20%" />
    <router-view/>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Background from "@/components/Background.vue"
import NavBar from "@/components/NavBar/NavBar.vue"

export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBar
  },
});
</script>


<style>
.notify {
  font-size: 28px;
  background: rgba(0, 0, 0, 0.6) !important;
  font: "Chakra Petch" !important;
  margin: 0 5px 5px;
  padding: 10px;
  border-left: 15px solid var(--magenta);
  color: var(--cyan);
  text-shadow: 0px 0px 20px var(--magenta);
}

/* .notify:success {
  background: #68cd86;
  border-left-color: #42a85f;
}

.notify:warn {
  background: #ffb648;
  border-left-color: #f48a06;
}

.notify:error {
  background: #e54d42;
  border-left-color: #b82e24;
} */

@font-face {
  font-family: "Chakra Petch";
  src: local("ChakraPetch"),
   url(./assets/fonts/ChakraPetch-Regular.ttf) format("truetype");
}
#app {
  font-family: "Chakra Petch";
}
:root{
  --tiny-text: 24px;
  --little-text: 32px;
  --middle-text: 48px;
  --large-text: 60px;
  --huge-text: 96px;
  --black: rgb(0, 0, 0);
  --cyan: rgb(30, 228, 216);
  --magenta: rgb(213, 30, 228);
  --violet: rgb(58, 13, 105);
  --navbar-height: 64px;
}
</style>
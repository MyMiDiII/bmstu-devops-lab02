<template>
  <UpperBackground class="component-row">
    <img src="../assets/img/user-logo.svg" height="100"/>

    <div class="component-column">
      <PinkText fontSize="var(--little-text)">{{player.nickname}}</PinkText>
      <BlueText fontSize="var(--tiny-text)">{{player.hoursPlayed}} hours</BlueText>
      <BlueText fontSize="var(--tiny-text)">{{date}}</BlueText>
    </div>
  </UpperBackground>
</template>


<script lang="ts">
import { defineComponent } from 'vue';
import UpperBackground from "@/components/UpperBackground.vue";
import BlueText from "@/components/BlueText.vue";
import PinkText from "@/components/PinkText.vue";

export default defineComponent({
  name: "PlayerItem",
  data () {
    return {
      player: {
        nickname: '',
        hoursPlayed: 0,
        lastPlayed: ''
      }
    }
  },
  components: {
    UpperBackground,
    BlueText,
    PinkText,
  },
  props: ['playerBase'],
  mounted() {
    this.player = this.playerBase;
    console.log(this.date);
  },
  computed: {
    date() {
      return (new Date(this.player.lastPlayed)).toLocaleDateString();
    }
  }
})
</script>


<style scoped>
  .component-row {
    display: flex;
    flex-direction: row;
    border-radius: 50px;
    height: 120px;
    width: 405px;
    justify-content: center;
    align-items: center;
    padding: 10px;
    gap: 10px;
    box-shadow: 0px 0px 10px var(--cyan);
  }

  .component-column {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }
</style>

<template>
  <UpperBackground class="search">
    <BlueText fontSize="var(--little-text)">Search by Name:</BlueText>
    <InputLine @serverName="setName" name="serverName" fontSize="var(--little-text)"/>
    <BlueText fontSize="var(--little-text)">Search by Game:</BlueText>
    <InputLine @gameName="setGame" name="gameName" fontSize="var(--little-text)"/>
    <BlueText fontSize="var(--little-text)">Platform:</BlueText>
    <Select
      @platform="setPlatform" 
      name="platform" 
      v-bind:options="platformOptions" 
      fontSize="var(--tiny-text)"
    />
  </UpperBackground>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import UpperBackground from "@/components/UpperBackground.vue"
import BlueText from "@/components/BlueText.vue"
import InputLine from "@/components/InputLine.vue"
import Select from "@/components/Select.vue"
import PlatformInterface from "@/Interfaces/PlatformInterface"

export default defineComponent({
  name: "ServerSearch",
  components: {
    UpperBackground,
    BlueText,
    InputLine,
    Select
  },
  data() {
    return {
      serverName: '',
      gameName: '',
      platformId: null,
      platformOptions: [],
    }
  },
  mounted () {
    PlatformInterface.getAll().then(json => {this.platformOptions = json.data});
  },
  methods: {
    setName(name: string) {
      console.log('new name')
      this.serverName = name
      this.$emit('name-input', this.serverName)
    },

    setGame(game: string) {
      console.log('new name')
      this.gameName = game
      this.$emit('game-input', this.gameName)
    },

    setPlatform(platformId: any) {
      this.platformId = platformId;
      console.log(this.platformId)
      this.$emit('platform-input', this.platformId)
    },
  }
})
</script>

<style scoped>
.search {
  display: flex;
  justify-content: space-between;
  width: calc(100% - 74px);
  padding: 10px;
  padding-left: 37px;
  padding-right: 37px;
}
</style>
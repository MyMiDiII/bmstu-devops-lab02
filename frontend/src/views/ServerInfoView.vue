<template>
  <NavBarView>
    <div class="container">
      <BlueText class="text" fontSize="var(--huge-text)">
        {{server.name}}
      </BlueText>

      <UpperBackground class="center">
        <div class="container-row">
          <div class="container-column">
            <PinkText fontSize="var(--middle-text)">
              Base
            </PinkText>
            <BlueText fontSize="var(--tiny-text)">
              Ip
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{server.ip}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Game
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{server.gameName}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Rating
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{server.rating}}
            </BlueText>
          </div>

          <div v-if="isNotGuest" class="container-column">
            <PinkText fontSize="var(--middle-text)">
              Hosting
            </PinkText>
            <BlueText fontSize="var(--tiny-text)">
              Name
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{hosting.name}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Price per Month
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{hosting.pricePerMonth}}$
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Month Number
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{hosting.subMonths}}
            </BlueText>
          </div>

          <div v-if="isNotGuest" class="container-column">
            <PinkText fontSize="var(--middle-text)">
              Platform
            </PinkText>
            <BlueText fontSize="var(--tiny-text)">
              Name
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{platform.name}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Popularity
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{platform.popularity}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Average Cost
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{platform.cost}}$
            </BlueText>
          </div>

          <div v-if="isNotGuest" class="container-column">
            <PinkText fontSize="var(--middle-text)">
              Country
            </PinkText>
            <BlueText fontSize="var(--tiny-text)">
              Name
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{country.name}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Level of Interest
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{country.levelOfInterest}}
            </BlueText>
            <BlueText fontSize="var(--tiny-text)">
              Players Number
            </BlueText>
            <BlueText fontSize="var(--middle-text)">
              {{country.overallPlayers}}
            </BlueText>
          </div>
        </div>
      </UpperBackground>

      <BlueText v-if="isNotGuest" class="text" fontSize="var(--large-text)">
          Players
      </BlueText>

      <div v-if="isNotGuest" class="player-row">
        <div v-for="player in players" v-bind:key="player">
          <PlayerItem v-bind:playerBase="player"></PlayerItem>
        </div>
      </div>
    </div>
  </NavBarView>
</template>


<script lang="ts">
import { defineComponent } from 'vue';
import NavBarView from "@/views/NavBarView.vue";
import BlueText from "@/components/BlueText.vue";
import PinkText from "@/components/PinkText.vue";
import UpperBackground from "@/components/UpperBackground.vue";
import PlayerItem from "@/components/PlayerItem.vue";

import HostingInterface from "@/Interfaces/HostingInterface"
import PlatformInterface from "@/Interfaces/PlatformInterface"
import CountryInterface from "@/Interfaces/CountryInterface"
import ServerInterface from "@/Interfaces/ServerInterface"
import auth from "@/authentificationService"

export default defineComponent({
  name: "ServerInfoView",
  data () {
    return {
      server: {
        id: 1,
        name: '',
        ip: '',
        gameName: '',
        hostingID: 0,
        platformID: 0,
        countryID: 0,
      },
      platform: {
        name: '',
        cost: 0,
        popularity: 0,
      },
      hosting: {
        name: '',
        pricePerMonth: 0,
        subMonths: 0,
      },
      country: {
        name: '',
        levelOfInterest: 0,
        overallPlayers: 0,
      },
      players: []
    }
  },
  computed: {
    isNotGuest() {
      return auth.getCurrentUser().role != "guest";
    }
  },
  async mounted () {
    this.server.id = Number(this.$route.params.id);
    this.server = await (await ServerInterface.getById(this.server.id)).data;
    this.platform = await (await PlatformInterface.getById(this.server.platformID)).data;
    this.hosting = await (await HostingInterface.getById(this.server.hostingID)).data;
    this.country = await (await CountryInterface.getById(this.server.countryID)).data;
    this.players = await (await ServerInterface.getPlayers(this.server.id)).data;

    console.log("role", this.isNotGuest);
  },
  components: {
    NavBarView,
    PinkText,
    BlueText,
    UpperBackground,
    PlayerItem,
  }
});
</script>


<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 15px;
}

.container-row {
  display: grid;
  grid-template-columns: 2fr 2fr 2fr 1fr;
  justify-content: space-between;
  width: 100%;
  gap: 10px;
}

.container-column {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.center {
  border-radius: 0px 50px 0px 50px;
  width: 90%;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 30px;
}

.text {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: left;
  width: 90%
}

.player-row {
  display: flex;
  flex-direction: row;
  gap: 30px;
  width: 90%;
  padding: 10px;
  overflow: auto;
}

.player-column {
  display: flex;
  flex-direction: column;
  width: 90%;
  gap: 10px;
  overflow: scroll;
  max-height: 330px;
}
</style>

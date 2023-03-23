<template>
    <button class="star" v-on:click="changeState">
        <img v-if="state" src="@/assets/img/star-on.svg"/>
        <img v-else src="@/assets/img/star-off.svg"/>
    </button>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

import UserInterface from "@/Interfaces/UserInterface"
import auth from "@/authentificationService"

export default defineComponent({
  name: "ServerStar",
  data() {
    return {
      state: false
    }
  },
  props: {
    serverId: {
      type: Number,
      default: 0
    },
  },
  methods: {
    changeState: function() {
      this.state = !this.state;

      if (this.state) {
        this.addFavoriteServer();
      }
      else {
        this.deleteFavoriteServer();
      }
    },
    
    addFavoriteServer() {
      const userId = auth.getCurrentUser().id;
      // console.log("AddFavoriteServer:", userId, this.serverId);
      UserInterface.addFavoriteServer(userId, this.serverId);
    },

    deleteFavoriteServer() {
      const userId = auth.getCurrentUser().id;
      // console.log("DeleteFavoriteServer:", userId, this.serverId);
      UserInterface.deleteFavoriteServer(userId, this.serverId);
    },

    async setServerState() {
      const userId = auth.getCurrentUser().id;
      const result = await UserInterface.getFavoriteServer(userId, this.serverId);

      if (result.status == 404) {
        console.log("No Server", this.serverId);
        this.state = false;
      }
      else {
        console.log("Yes Server", this.serverId);
        this.state = true;
      }
    }
  },
  mounted() {
    this.setServerState();
  }
})
</script>

<style scoped>
.star {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}
</style>

<template>
  <div class="container">
    <ServerItem
      class="item"
      :mode="mode"
      v-for="server in servers"
      v-bind:server="server"
      v-bind:key="server.id">
    </ServerItem>
  </div>
  <Paging v-bind:page="currentPage"
          v-on:next-page="nextPage"
          v-on:prev-page="prevPage"
          class="for-list"/>
  {{ currentPage }}
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import ServerItem from "@/components/Servers/ServerItem.vue"
import Paging from "@/components/Paging/Paging.vue"

import ServerInterface from "@/Interfaces/ServerInterface"
import UserInterface from "@/Interfaces/UserInterface"
import auth from "@/authentificationService"

export default defineComponent({
  name: "ServerList",
  components: {
    ServerItem,
    Paging
  },
  props: {
    mode: {
      type: String,
      default: 'guest'
    },
    initPage: {
      type: Object,
      default: { num: 1, isLast: false}
    },
    initName: {
      type: String,
      default: ''
    },
    initGame: {
      type: String,
      default: ''
    },
    initPlatformId: {
      default: null
    },
  },
  data() {
    return {
      servers: [],
      currentPage: this.initPage,
      ownerId: null,
      status: Number
    }
  },
  watch: {
    initName: function() {
      console.log("what")
      this.getServers();
    },

    initGame: function() {
      console.log("what")
      this.getServers();
    },

    initPlatformId: function() {
      console.log("what")
      this.getServers();
    }
  },
  mounted() {
    this.getServers();
  },
  methods: {
    nextPage() {
      console.log(this.initName)
      console.log("next page")
      this.currentPage.num += 1
      // ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, this.currentPage.num, 4).then(json => {this.servers = json.data})
      // ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, this.currentPage.num + 1, 4).then(json => {
      //   this.currentPage.isLast = (json.data.length == 0)
      // })
      this.getServers();
      this.$emit('new-page', this.currentPage.num)
    },

    prevPage() {
      console.log("prev page")
      this.currentPage.num -=1
      this.currentPage.isLast = false
      // ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.currentPage.num, 4).then(json => {this.servers = json.data})
      this.getServers();
      this.$emit('new-page', this.currentPage.num )
    },

    getServers() {
      if (this.mode == "user-status") {
        this.ownerId = auth.getCurrentUser().id;
      }

      console.log(this.ownerId);
      ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, 0, this.currentPage.num, 4).then(json => {this.servers = json.data});
      ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, 0, this.currentPage.num + 1, 4).then(json => {
        this.currentPage.isLast = (json.data.length == 0)
      });

      if (this.mode == "admin-suggest") {
        ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, 1, this.currentPage.num, 4).then(json => {this.servers = json.data; console.log(json.data)});
        ServerInterface.getAll(this.initName, this.initGame, this.initPlatformId, this.ownerId, 1, this.currentPage.num + 1, 4).then(json => {
          this.currentPage.isLast = (json.data.length == 0)
        });
      }

      if (this.mode == "favorite") {
        const userId = auth.getCurrentUser().id;
        UserInterface.getAllFavorites(userId, this.initName, this.initGame, this.initPlatformId, this.currentPage.num, 4).then(json => {this.servers = json.data});
        UserInterface.getAllFavorites(userId, this.initName, this.initGame, this.initPlatformId, this.currentPage.num + 1, 4).then(json => {
          this.currentPage.isLast = (json.data.length == 0)
        });
      }
    }
  }
})
</script>

<style scoped>
.container {
  display: flex;
  flex-wrap: wrap;
  align-content: space-between;
  min-height: 550px;
  width: 100%
}
.for-list {
  font-size: var(--tiny-text);
  width: 100%;
  justify-content: right;
}
</style>

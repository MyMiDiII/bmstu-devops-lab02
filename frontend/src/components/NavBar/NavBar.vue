<template>
  <nav class="nav-container">
    <router-link style="text-decoration: none" to="/">
      <BlueText :fontSize="'var(--middle-text)'">
        ServerING
      </BlueText>
    </router-link>
    <!-- <div style="display: flex; gap: 20px">
        <Button v-on:click="setGuest">Guest</Button>
        <Button v-on:click="setUser">User</Button>
        <Button v-on:click="setAdmin">Admin</Button>
    </div> -->
    <div v-if="isInRole == 'user'">
      <UserNavbarMenu />
    </div>
    <div v-else-if="isInRole == 'admin'">
      <AdminNavbarMenu />
    </div>
    <div v-else>
      <GuestNavbarMenu />
    </div>
  </nav>
</template>

<script lang="ts">
import { defineAsyncComponent, defineComponent } from 'vue'
import BlueText from "@/components/BlueText.vue"
import Button from '@/components/Button.vue'
import GuestNavbarMenu from '@/components/NavBar/GuestNavbarMenu.vue'
import UserNavbarMenu from '@/components/NavBar/UserNavbarMenu.vue'
import AdminNavbarMenu from '@/components/NavBar/AdminNavbarMenu.vue'

import auth from '@/authentificationService'
import UserInterface from '@/Interfaces/UserInterface'

export default defineComponent({
  name: "NavBar",
  components: {
    BlueText,
    Button,
    GuestNavbarMenu,
    UserNavbarMenu,
    AdminNavbarMenu
  },
  data() {
    return {
      componentName: 'GuestNavbarMenu'
    }
  },
  computed: {
    isInRole () {
      return auth.getCurrentUser().role;
    }
  },
  methods: {
    setGuest: function() {
      console.log('guest')
      console.log(auth.getCurrentUser())
      this.componentName = 'GuestNavbarMenu'
    },
    setUser: function() {
      auth.logout()
      location.reload()
    },
    setAdmin: async function() {
      console.log(await UserInterface.getAll());
      console.log('admin')
      this.componentName = 'AdminNavbarMenu'
    },
  }
})
</script>


<style>
.nav-container {
  position: fixed;
  height: var(--navbar-height);
  background-color: var(--violet);
  box-shadow: inset 0px 0px 40px rgba(213, 30, 228, 0.6);
  left: 0;
  right: 0;
  padding-left: 1.4rem;
  padding-right: 1.4rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.nav-menu {
    display: flex;
    gap: 20px
}
</style>
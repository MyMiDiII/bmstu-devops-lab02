<template>
  <NavBarView>
    <div class="container">
      <div class="title">
        <BlueText class="text" fontSize="var(--huge-text)">
          Servers Control
        </BlueText>

        <router-link style="text-decoration: none" to="/server-add">
          <Button style="height: 50%; width: 250px">Add</Button>
        </router-link>
      </div>
            
      <ServerSearch style="margin-bottom: 20px; width: calc(100% - 74px);"/>
      <ServerList v-bind:initPage="currentPage" v-on:new-page="newPage" mode='admin'/>
    </div>
  </NavBarView>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBarView from "@/views/NavBarView.vue"
import BlueText from "@/components/BlueText.vue"
import ServerList from "@/components/Servers/ServerList.vue"
import ServerSearch from "@/components/Servers/ServerSearch.vue"
import Button from "@/components/Button.vue"

export default defineComponent({
  name: "HomeView",
  components: {
    NavBarView,
    BlueText,
    ServerList,
    ServerSearch,
    Button,
  },
  //data() {
  //  return {
  //    currentPage: {
  //      num: 1,
  //      isLast: false
  //    }
  //  }
  //},
  computed: {
    currentPage() {
      console.log(1)
      if ("page" in this.$route.query) {
        console.log(2)
        const page = this.$route.query.page;

        if (typeof page === 'string') {
          console.log(3)
          return { num: parseInt(page), isLast: false };
        }
      }
      console.log(4)

      return { num: 1, isLast: false };
    }
  },
  //mounted() {
  //  console.log(this.$route.params.page)
  //  if ("page" in this.$route.query) {
  //    console.log("page in")
  //    const page = this.$route.query.page;

  //    if (typeof page === 'string') {
  //      console.log(page)
  //      this.currentPage.num = parseInt(page);
  //    }
  //  }
  //},
  methods: {
    newPage(pageNumber: Number) {
      this.$router.push({ path: '/servers-control', query: { page: pageNumber.toString() } })
    },
  },
});
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px;
}
.text {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: left;
  width: 100%;
}

.title {
  display: grid;
  grid-template-columns: 5fr 1fr;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  gap: 10px;
}
</style>

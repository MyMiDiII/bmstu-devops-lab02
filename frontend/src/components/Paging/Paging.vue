<template>
    <PagingFirst v-if="page.num === 1" />
    <PagingLast v-else-if="page.isLast"> {{ page.num }} </PagingLast>
    <PagingMiddle v-else> {{ page.num }} </PagingMiddle>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import PagingFirst from "@/components/Paging/PagingFirst.vue"
import PagingLast from "@/components/Paging/PagingLast.vue"
import PagingMiddle from "@/components/Paging/PagingMiddle.vue"

export default defineComponent({
  name: "Paging",
  components: {
    PagingFirst,
    PagingMiddle,
    PagingLast
  },
  props: {
    page: {
      num: Number,
      isLast: Boolean,
      required: true
    },
  }
})
</script>

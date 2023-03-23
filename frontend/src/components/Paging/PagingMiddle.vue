<template>
    <div class="paging-middle">
        <DropDownButton v-on:click="$emit('prev-page')" rotateAngle=90deg />
        <BlueText><slot></slot></BlueText>
        <DropDownButton v-on:click="$emit('next-page')" rotateAngle=270deg />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import BlueText from "@/components/BlueText.vue"
import DropDownButton from "@/components/DropDownButton.vue"

export default defineComponent({
    name: "PagingMiddle",
    components: {
        BlueText,
        DropDownButton
    },
    props: {
        size: String
    }
})
</script>


<style scoped>
    .paging-middle {
        display: flex;
        gap: 5px;
    }
</style>

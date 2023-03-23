<template>
    <div class="paging-last">
        <DropDownButton v-on:click="$emit('prev-page')" rotateAngle=90deg />
        <BlueText><slot></slot></BlueText>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import BlueText from "@/components/BlueText.vue"
import DropDownButton from "@/components/DropDownButton.vue"

export default defineComponent({
    name: "PagingLast",
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
    .paging-last {
        display: flex;
        gap: 5px;
    }
</style>

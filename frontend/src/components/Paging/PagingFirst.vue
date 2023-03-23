<template>
    <div class="paging-first">
        <BlueText>1</BlueText>
        <DropDownButton v-on:click="$emit('next-page')" rotateAngle=270deg />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import BlueText from "@/components/BlueText.vue"
import DropDownButton from "@/components/DropDownButton.vue"

export default defineComponent({
    name: "PagingFirst",
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
    .paging-first {
        display: flex;
        gap: 5px;
    }
</style>

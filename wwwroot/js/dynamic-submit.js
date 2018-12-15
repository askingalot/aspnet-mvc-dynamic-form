(function() {
    const form = document.getElementById("quote-form");
    form.addEventListener("submit", (e) => {
        // READ THIS
        //  A combination of e.preventDefault() and returning false
        //  means that the form won't really submit
        //  We send the data in the postViewmodel function

        e.preventDefault();

        const selectedRatings = formElementsToSelectedRatings(form.elements);
        const viewmodel = selectedRatingsToQuoteRatingViewModel(selectedRatings);
        postViewmodel(viewmodel);

        return false;
    });

    function formElementsToSelectedRatings(elements) {
        const selectedRatings = {}
        for (let i=0; i<elements.length; i++) {
            let el = elements[i]
            if (el.type !== 'radio') {
                continue;
            }
            if (!selectedRatings[el.name]) {
                selectedRatings[el.name] = null;
            }
            if (el.checked) {
                selectedRatings[el.name] = el.value;
            }
        }
        return selectedRatings;
    }

    function selectedRatingsToQuoteRatingViewModel(selectedRatings) {
        // READ THIS
        //  This function creates Quote and Rating objects that ONLY HAVE IDs
        //  This means that when we get to C# ONLY the ID will be populated

        const viewmodel = {
            quoteRatings: [ ]
        };
        const ratingNames = Object.keys(selectedRatings);
        for (let i=0; i<ratingNames.length; i++) {
            const ratingName = ratingNames[i];

            // rating name is in the form "rating-<quote id>"
            const quoteId = ratingName.split('-')[1];
            const quote = {
                id: quoteId
            };

            // the value of the "ratingName" key is the rating id
            const ratingId = selectedRatings[ratingName];
            const rating = {
                id: ratingId
            };

            viewmodel.quoteRatings.push({ quote:quote, rating:rating });
        }

        return viewmodel;
    }

    function postViewmodel(viewmodel) {
        const postData = {
            headers: { "Content-Type": "application/json" },
            method: "POST",
            body: JSON.stringify(viewmodel)
        };
        fetch('/', postData).then(resp => alert("It submitted!"));
        // READ THIS
        // Because we are submitting this data via javascript, 
        //  we will have to use javascript to redirect the user to another
        //  page if the post was successful.
    }
}());